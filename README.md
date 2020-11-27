# Web application exercise

This exercise's purpose is to create a backend service that returns sensor data from the database. Database `iot_db.sqlite` has around 250k rows of sensor data.

We may decide not to continue recruitment process based on this test, so it is recommended that you have good proficiency in the language you choose to use and also show it in this test.

### Getting started

1. Select technology you want to use.
    * C, C++, C#, Java, JavaScript, PHP, Python, Rust, Scala, Clojure, or Go.
    * If you want use something else, ask first.
    * You can use supporting libraries and frameworks.
2. Create your application.

### Functionality

Service should have these functionalities.

##### Sensor data summary

1. Get data from database table `cubesensors_data` as fast as possible.
2. Count amount of data per sensor and average temperature for each sensor.
3. Return data in JSON format.

Temperatures are stored as hundredths of degrees. For example, `1234` is `12.34` degrees Celsius.

```
{
    "sensors" : [
        { "sensorId" : "000A1F0003141E11", "count" : 500, "avgTemp" : 21.4 },
        { "sensorId" : "000B2F0003141E22", "count" : 20, "avgTemp" : 19.7 }
    ]
}
```


##### Temperature difference

1. Get selected sensor's latest temperature.
2. Get Helsinki's current temperature from http://wttr.in/Helsinki. Temperature is in the first element that ends with ```</span> °C``` e.g. ```<span class="xxxx">-1</span> °C```.
3. Calculate the difference of these two values.
4. Return data in JSON format.

```
{
    "difference" : 14.56
}
```

### Architecture and design

1. Implement interface so `htmlapp/index.html` can get data from the service. There should be no need to modify the app.
2. Design a good architecture that will support different application scenarios.
3. Write understandable code.

Other applications could also use this service in the future. For example

* a C++/C#/Java/JavaScript/Python/Go/... client, or
* another application as an e.g. Maven dependency, Node module, Python package, class library or other module.

### Important

Anyone can write or copy-paste basic small app, so remember to show your design and architecture skills.

### Tips

* You can comment what you would do.
* Be ready to explain things in the interview.
* Testing and mocking should be done as if this would be production code.

