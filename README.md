# Business Trip Advisor - Web Application
(Under Construction)

Application hosted on: [bta.somee.com](http://bta.somee.com)

## Short description
This Application is for sharing experience of city life and accommodations between employees of business organization.
Application user can see list of cities where can leave feedback about life in the city or about accommodation there.
City information contains of description, position on the map, feedbacks about life in city and accommodations.
Feedbacks have their title, comment, category, position on the map, rating... 
Accommodations have their category, name, description, position on the map, its feedbacks (accommodation feedbacks)..

## Roles
There are 2 role implemented, administrator and traveler. User must be logged in to use this application.
Administrator can add/modify/delete city.
Administrator and Traveler can add new feedback (edit and delete are not yet implemented).

## Credentials
Default credentials for administrator:

user: `admin@bta.com`

pass: `Admin!23`

## Developer Here
For showing position on map for cities and feedbacks, Developer Here APIs are used. Here's a link: 
[https://developer.here.com](https://developer.here.com)

APIs used:
- autocomplete (for getting all possible cities which have same part of text in their names)
- geocoding (for getting geocoordinates for locationId of the place, got from object from autocomplete API)
- maps (for displaying map in browser, used geocoordinates for zoom to city, mark feedback, ...)
- weather (for 7 days weather forecast, not yet implemented)

## Web Hosting
This Application has been hosted on [bta.somee.com](http://bta.somee.com)

Application files uploaded by ftp, and database uploaded by sql script (create tables and seeds) 

## Done until now:
- Most of pages design
- Log in and Sign Up
- Life in different countries
  - Administrator can add/edit/delete city
  - Administrator and Traveler can add new feedback
  - Cities API controller built to work with table Cities in database
  - CityLifeFeedback API controller built to work with feedbacks about life in a city, from database
    - used CityLifeFeedbackViewModel and UserViewModel when returning data from database
  - Developer Here APIs are used to display position of city and feedbacks on map

## Future goals
- Life in different countries
  - Add weather forecast for 7 days in city details
  - Authorize APIs
  - Add anti-forgery tokens in forms, and implement validations in APIs
  - Administrator can edit/delete any feedback
  - Traveler can edit/delete only his/her own feedback
- Acccommodations
  - Build API for Accomodation table and Accommodation feedbacks table in database
  - Build View Models for APIs
  - Validate and authorize APIs
- Feedbacks
  - User can see all his feedbacks, and edit/delete those
- User can add comments on feedbacks
- Upload images on server
  - User profile image
  - City images
  - Feedback images
  - Accommodation images
