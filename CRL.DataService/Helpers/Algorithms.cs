using CRL.DataAccess.Interfaces;
using CRL.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRL.DataService.Helpers
{
    /*This class' idea is to provide different algorithms 
    for finding a city that could be a logistic center*/
    public class Algorithms
    {
        private readonly IDataAccessService dataAccessService;

        public Algorithms(IDataAccessService dataAccessService)
        {
            this.dataAccessService = dataAccessService;
        }

        public CityEntity FindLogisticCenter(CityEntity node)
        {
            //applying Prim's algorithm could provide us the Minimum Spanning tree
            List<RouteEntity> maxSpanningTreeRoutes = ApplyPrim(node);
            List<CityEntity> cities = dataAccessService.CityRepository.GetAll().ToList();
            
            /*for each of the cities we define the Closeness Centrality Coeficient 
              which is a 1 divided by the sum of all routes between a given city and
              all other cities */
            foreach (CityEntity city in cities)
            {
                double fullDistance = 0;
                List<RouteEntity> visited = new List<RouteEntity>();
                //keep the calculated path weight for every city in a dictionary
                Dictionary<int, double> calculatedRoutes = new Dictionary<int, double>();
                //the path weight from the current city to itself is evaluated as 0
                calculatedRoutes.Add(city.Id, 0);
                int currentId;
                //when going through the tree we keep tracking cities in a queue
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(city.Id);
                while (queue.Any())
                {
                    currentId = queue.Dequeue();
                    List<RouteEntity> routes = maxSpanningTreeRoutes.Where(r => r.Start.Id == currentId || r.End.Id == currentId).ToList();
                    foreach (var route in routes)
                    {
                        if (!visited.Contains(route))
                        {
                            //the calculated path is equal to the path before the dequeued city added to the route's distance
                            if (route.End.Id == currentId)
                            {
                                calculatedRoutes.Add(route.Start.Id, calculatedRoutes[currentId] + route.Distance);
                                queue.Enqueue(route.Start.Id);
                            }
                            else if (route.Start.Id == currentId)
                            {
                                calculatedRoutes.Add(route.End.Id, calculatedRoutes[currentId] + route.Distance);
                                queue.Enqueue(route.End.Id);
                            }
                            visited.Add(route);
                        }
                    }
                }
                fullDistance = calculatedRoutes.Values.Sum();
                city.ClosenessCentralityCoefficient = 1 / fullDistance;
                this.dataAccessService.CityRepository.Update(city);
            }
            //returns the city with the highest Closeness Centrality Coeficient
            return cities.Where(c => c.ClosenessCentralityCoefficient == cities.Max(c1 => c1.ClosenessCentralityCoefficient)).FirstOrDefault();
        }

        /* This method applies Prim's algorithm to the cities and routes 
         saved in the database*/
        private List<RouteEntity> ApplyPrim(CityEntity node)
        {
            Node root = new Node(node.Id, null);
            int allNodes = dataAccessService.CityRepository.GetCount();
            List<RouteEntity> treeRoutes = new List<RouteEntity>();
            List<RouteEntity> available = new List<RouteEntity>();
            List<CityEntity> visitedCities = new List<CityEntity>();
            List<RouteEntity> routes = dataAccessService.RouteRepository.GetRoutesByCity(node.Id, visitedCities.Select(c => c.Id).ToArray());

            /*until all the routes are visited or the tree routes are not as many as 
              the number of the cities - 1*/
            while (treeRoutes.Count != allNodes - 1 && routes.Count != 0)
            {
                //getting available routes
                available.AddRange(routes);
                //selecting the min route
                RouteEntity forAdd = available.Where(a => a.Distance == available.Min(a2 => a2.Distance)).FirstOrDefault();
                if (forAdd != null)
                {
                    treeRoutes.Add(forAdd);
                    available.Remove(forAdd);
                    visitedCities.Add(node);
                    if (forAdd.End?.Id != node.Id)
                        node = forAdd.End;
                    else
                        node = forAdd.Start;
                    //removing routes that connect already visited cities
                    List<RouteEntity> forRemoval = available.Where(r => visitedCities.Select(c => c.Id).ToArray().Contains(r.Start.Id)
                                                                     && visitedCities.Select(c => c.Id).ToArray().Contains(r.End.Id)).ToList();
                    foreach (var item in forRemoval)
                    {
                        available.Remove(item);
                    }

                }
                routes = dataAccessService.RouteRepository.GetRoutesByCity(node.Id, visitedCities.Select(c => c.Id).ToArray());
            }
            return treeRoutes;
        }
    }

    public class Node
    {
        public int CityId { get; set; }
        public Node Parent { get; set; }
        public Dictionary<Node, int> Children { get; set; }

        public Node(int cityId, Node parent)
        {
            this.CityId = cityId;
            this.Parent = parent;
            this.Children = new Dictionary<Node, int>();
        }
    }
}
