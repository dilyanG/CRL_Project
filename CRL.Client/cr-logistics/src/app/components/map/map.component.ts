import { Component, OnInit, NgZone } from '@angular/core';
import { RouteService } from '../../services/route.service';

import * as am4core from "@amcharts/amcharts4/core";
import * as am4charts from "@amcharts/amcharts4/charts";
import am4themes_animated from "@amcharts/amcharts4/themes/animated";
import * as am4plugins_forceDirected from "@amcharts/amcharts4/plugins/forceDirected";

import { RouteModel } from '../../models/route.model';

am4core.useTheme(am4themes_animated);


@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {

  private chart: am4plugins_forceDirected.ForceDirectedTree;


  constructor(private routeService: RouteService,
    private zone: NgZone) { }

  ngOnInit() {

  }
  ngAfterViewInit() {
    this.zone.runOutsideAngular(() => {
      let chart = am4core.create("chartdiv", am4plugins_forceDirected.ForceDirectedTree);
      let series = chart.series.push(new am4plugins_forceDirected.ForceDirectedSeries());


      this.routeService.getRoutes().subscribe(
        res => {
          chart.paddingRight = 20;
          let data = [];
          for (let route of res) {
            
            if (!data.find(r => r.name == route.start.name))
              data.push({ name: route.start.name, link: [route.end.name], children: [] });
            else if (!data.find(r => r.name == route.end.name))
              data.push({ name: route.end.name, link: [route.start.name], children: [] });
            else if (data.find(r => r.name == route.start.name))
              data.find(r => r.name == route.start.name).children = [...data.find(r => r.name == route.start.name).children, { name: route.end.name, value: route.distance }];
            else if (data.find(r => r.name == route.end.name))
              data.find(r => r.name == route.end.name).children = [...data.find(r => r.name == route.end.name).children, { name: route.start.name, value: route.distance }];

            //data.find(r => r.name == route.start.name).children = [...data.find(r => r.name == route.start.name).children,  route.end.name];
          }

          series.data = data;
          // Set up data fields
          series.dataFields.value = "value";
          series.dataFields.name = "name";
          series.dataFields.children = "children";
          series.dataFields.id = "name";
          series.dataFields.linkWith = "link";
          // Add labels
          series.nodes.template.label.text = "{name}";
          series.fontSize = 10;
          series.minRadius = 15;
          series.maxRadius = 40;


          this.chart = chart;
        }
      )
    });
  }

  ngOnDestroy() {
    this.zone.runOutsideAngular(() => {
      if (this.chart) {
        this.chart.dispose();
      }
    });
  }

}
