# WeatherForecast

WeatherForecast is a .Net Core application used to forecast weather of next 5 days

## Installation

1- Download the project
2- Open in visual studio.
3- Update connection string in app.config file of WeatherForecast.Api and WeatherForecast.Service project. (Mongo DB should be installed on machine)
4- Run Weather API project to get stored results from DB
5- Run Weather APi project and Weather Service project simultaneously to obtain the latest weather data from weather api
6- WeatherForecast.Service is a schedular which will run every X hour to obtain results, and store results when conditions matches. 
when run WeatherForecast.Service project open URL https://localhost:44324/hangfire in browser
6- Api to optaon the store data will run automatically and return results when WeatherForecast.API project will be running
7- The project is using code first approach hence database and tables will be created automatically as the project will be runing. 
