using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WeatherForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            weatherget();
        }

        public async void weatherget()
        {
            RootObject getweather = await WeatherClass.GetWeather(textBox1.Text);
            label4.Text = getweather.name;
            label5.Text = (getweather.main.temp - 273.15).ToString() + "°C";
            label6.Text = getweather.weather[0].description;
            label7.Text = getweather.main.humidity.ToString() + " %";
            label8.Text = getweather.name;
            minLabel.Text = (getweather.main.temp_min - 273.15).ToString() + "°C";
            maxLabel.Text = (getweather.main.temp_max - 273.15).ToString() + "°C";
            humidityLabel.Text = getweather.main.humidity.ToString() + " %";
            pressureLabel.Text = getweather.main.pressure.ToString() + " hpa";
            speedLabel.Text = getweather.wind.speed.ToString() + " m/s";
            degreeLabel.Text = getweather.wind.deg.ToString() + "°";
            visibilityLabel.Text = (getweather.visibility / 100).ToString() + "%";
            latLabel.Text = getweather.coord.lat.ToString();
            lonLabel.Text = getweather.coord.lon.ToString();
            //DateTimeOffset dateTimeOffset = DateTimeOffset.
            riseLabel.Text = FromUnixTime(getweather.sys.sunrise).ToString();
            setLabel.Text = FromUnixTime(getweather.sys.sunset).ToString();
            string icon = string.Format("http://openweathermap.org/img/w/{0}.png", getweather.weather[0].icon);
            weatherPicBox.Load(icon);

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            weatherget();
        }

        public static DateTime FromUnixTime(long unixTime)
        {
            //return epoch.AddSeconds(unixTime);
            return epoch.ToLocalTime().AddSeconds(unixTime);
        }
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    }
}
