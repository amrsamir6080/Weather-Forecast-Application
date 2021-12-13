using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.openweathermapModels;
using WeatherApp.Repositories;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherRepository _WeatherRepository;
        public WeatherController(IWeatherRepository WeatherRepository)
        {
            _WeatherRepository = WeatherRepository;
        }



        [HttpGet]
        public IActionResult SearchByCity()
        {
            var viewModel = new SearchByCity();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult SearchByCity(SearchByCity model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "Weather", new { City = model.CityName });
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult City(string city)
        {
            WeatherResponse weatherRsponse = _WeatherRepository.GetForecast(city);
            City viewModel = new City();
            if (weatherRsponse != null)
            {
                viewModel.Name = weatherRsponse.Name;
                viewModel.Temperature = weatherRsponse.Main.Temp;
                viewModel.Humidity = weatherRsponse.Main.Humidity;
                viewModel.Pressure = weatherRsponse.Main.Pressure;
                viewModel.Weather = weatherRsponse.Weather[0].Main;
                viewModel.Wind = weatherRsponse.Wind.Speed;
            }
            return View(viewModel);
        }
    }
}
