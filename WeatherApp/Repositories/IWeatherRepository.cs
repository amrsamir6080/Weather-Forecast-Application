﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.openweathermapModels;

namespace WeatherApp.Repositories
{
    public interface IWeatherRepository
    {
        WeatherResponse GetForecast(string city);
    }
}
