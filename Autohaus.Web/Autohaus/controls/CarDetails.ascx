<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CarDetails.ascx.cs" Inherits="Autohaus.Web.UI.Controls.CarDetails" %>

<section id="header">
    <div class="page-header">
        <h1><%= Model.Year %> <%= Model.Data.Make %> <%= Model.Data.Model %> <%= Model.Data.Trim %></h1>
    </div>
</section>
<section id="images">
    <div class="row-fluid">
        <% if (Model.Images.Any())
           { %>
            <div id="myCarousel" class="carousel slide">
                <!-- Carousel items -->
                <div class="carousel-inner">
                    <div class="active item">
                        <img src="<%= Model.Images.FirstOrDefault() %>" />
                    </div>
                    <% foreach (string imageUrl in Model.Images.Skip(1))
                       { %>
                        <div class="item">
                            <img src="<%= imageUrl %>" />
                        </div>
                    <% } %>
                </div>
                <!-- Carousel nav -->
                <a class="carousel-control left" href="#myCarousel" data-slide="prev">&lsaquo;</a>
                <a class="carousel-control right" href="#myCarousel" data-slide="next">&rsaquo;</a>
            </div>
        <% } %>
    </div>
</section>
<section>
    <h2 id="h2">Body Specs</h2>
    <table class="table table-striped">
        <thead>
            <tr>
                <th>Body Type</th>
                <th>Seats</th>
                <th>Doors</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td><%= Model.Body %></td>
                <td><%= Model.Seats %></td>
                <td><%= Model.Doors %></td>
            </tr>
        </tbody>
    </table>
</section>
<section>
    <h2 id="headings">Fun Specs</h2>
    <table class="table table-striped">
        <thead>
            <tr>
                <th>Engine</th>
                <th>Engine Horsepower, Engine RPM, Engine Torque</th>
                <th>Top Speed (km/h)</th>
                <th>Acceleration (0-100 km/h)</th>
                <th>Transmission</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td><%= Model.EngineDescription %></td>
                <td><%= Model.EnginePower %></td>
                <td><%= Model.TopSpeed %></td>
                <td><%= Model.Acceleration %></td>
                <td><%= Model.Transmission %></td>
            </tr>
        </tbody>
    </table>
</section>
<section>
    <h2 id="h1">Efficiency</h2>
    <table class="table table-striped">
        <thead>
            <tr>
                <th>Mileage Hwy, l/100 km</th>
                <th>Mileage City, l/100 km</th>
                <th>Mileage Mixed, l/100 km</th>
                <th>Fuel Type</th>
                <th>Fuel Capacity</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td><%= Model.MileageHwy %></td>
                <td><%= Model.MileageCity %></td>
                <td><%= Model.MileageMixed %></td>
                <td><%= Model.FuelType %></td>
                <td><%= Model.FuelCapacity %></td>
            </tr>
        </tbody>
    </table>
</section>
<section>
    <h2 id="h3">Size & Dimensions</h2>
    <table class="table table-striped">
        <thead>
            <tr>
                <th>Dimensions (Weight, Length, Width, Height, Wheelbase)</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td><%= Model.Dimensions %></td>
            </tr>
        </tbody>
    </table>
</section>