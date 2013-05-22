<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Slideshow.ascx.cs" Inherits=" Autohaus.Web.UI.Controls.Slideshow" %>
<style>
    .cb-slideshow li span {
        -moz-animation: imageAnimation <%= TotalAnimation %>s linear infinite 0s;
        -ms-animation: imageAnimation <%= TotalAnimation %>s linear infinite 0s;
        -o-animation: imageAnimation <%= TotalAnimation %>s linear infinite 0s;
        -webkit-animation: imageAnimation <%= TotalAnimation %>s linear infinite 0s;
        animation: imageAnimation <%= TotalAnimation %>s linear infinite 0s;
    }

    .cb-slideshow li div {
        -moz-animation: titleAnimation <%= TotalAnimation %>s linear infinite 0s;
        -ms-animation: titleAnimation <%= TotalAnimation %>s linear infinite 0s;
        -o-animation: titleAnimation <%= TotalAnimation %>s linear infinite 0s;
        -webkit-animation: titleAnimation <%= TotalAnimation %>s linear infinite 0s;
        animation: titleAnimation <%= TotalAnimation %>s linear infinite 0s;
    }
</style>

<ul class="cb-slideshow">
    <li>
        <span style="background-image: url('<%= SlideshowImages[0].ImageUrl %>');">Image 1</span>
        <div>
            <h4><%= SlideshowImages[0].Title %></h4>
            <p><%= SlideshowImages[0].Attribution %></p>
        </div>
    </li>
    <% for (var i = 1; i < SlideshowImages.Count(); i++)
       { %>
    <li>
        <span style="-moz-animation-delay: <%= i*SlideDelay %>s; -ms-animation-delay: <%= i*SlideDelay %>s; -o-animation-delay: <%= i*SlideDelay %>s; -webkit-animation-delay: <%= i*SlideDelay %>s; animation-delay: <%= i*SlideDelay %>s; background-image: url('<%= SlideshowImages[i].ImageUrl %>');">Image <%= i + 1 %></span>
        <div style="-moz-animation-delay: <%= i*SlideDelay %>s; -ms-animation-delay: <%= i*SlideDelay %>s; -o-animation-delay: <%= i*SlideDelay %>s; -webkit-animation-delay: <%= i*SlideDelay %>s; animation-delay: <%= i*SlideDelay %>s;">
            <h4><%= SlideshowImages[i].Title %></h4>
            <%= SlideshowImages[i].Attribution %>
        </div>
    </li>
    <% } %>
</ul>
