import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';

import Chart from 'chart.js/auto';
import ChartDataLabels from 'chartjs-plugin-datalabels';

import Swiper from 'swiper';
import 'swiper/css';
import 'swiper/css/navigation';
import 'swiper/css/pagination';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, AfterViewInit {

  @ViewChild("pointsChart", {static: true}) pointChart: ElementRef;
  @ViewChild("programChart", {static: true}) programChart: ElementRef;
  
  constructor() { } 

  ngAfterViewInit(): void {
    var swiper = new Swiper(".future-container", {
      observer: true,
      observeParents: true,
      loop: true,
      effect: "coverflow",
      grabCursor: true,
      centeredSlides: true,
      slidesPerView: "auto",
      spaceBetween: 32,
      coverflowEffect: {
        rotate: 0,
      },
      pagination: {
        el: ".swiper-pagination",
      },
    });
  }

  ngOnInit(): void {
    const pointsChart = new Chart(
      this.pointChart.nativeElement.getContext('2d'),
      {
        type: 'line',
        data: this.data,
        options: {
            responsive: true,
            maintainAspectRatio: false,
            animations: {
                tension: {
                  duration: 1000,
                  delay: 500,
                  easing: 'linear',
                  loop: false
                }
            },
            scales: {
                y: {
                  min: 280,
                  max: 360
                }
              }
        }
      }
    );  

    const eduChart = new Chart(
      this.programChart.nativeElement.getContext('2d'),
      {
        type: 'pie',
        data: this.polarData,
            options: {
            maintainAspectRatio: false,
              plugins: {
                  tooltip: {
                    enabled: false,
                  },
                  datalabels: {
                    formatter: (value: any, context:any) => {return value + '%';}
                  }
              }
            },
            plugins: [ChartDataLabels]
        }
    );
  }

  labels = [
    2013,
    2014,
    2015,
    2016,
    2017,
    2018,
    2019,
    2020,
    2021,
  ];

  data = {
    labels: this.labels,
    datasets: [{
      label: 'Проходной балл',
      backgroundColor: 'rgb(255, 99, 132)',
      borderColor: 'rgb(255, 99, 132)',
      data: [315, 291, 308, 309, 336, 342, 332, 333, 322],
    }]
  };

  polarData = {
    labels: [
      'Математика и физика',
      'КМ и СА',
      'ИТ',
      'Гуманитарный блок',
    ],
    datasets: [{
      label: 'Программа',
      data: [48, 26, 15, 12],
      backgroundColor: [
        'rgb(54, 162, 235)',
        'rgb(255, 99, 132)',
        'rgb(255, 205, 86)',
        'rgb(75, 192, 192)',
      ]
    }]
  };
}
