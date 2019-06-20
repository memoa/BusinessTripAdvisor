// Loads cities list and feedbacks of each city listed
// Cities are filtered by name of city in cityFilter
// If cityFilter is null, there are no filtering cities
// Feedbacks are filterer by category (tag string)
// If category is 'All', there are no filtering feedbacks 
function loadCities(cityFilter, category) {
    $('#ponuda').empty();

    // Get all feedbacks from database
    $.ajax({
        url: '/api/cityLifeFeedbacks',
        method: 'GET',
        success: function (responseData) {
            feedbacksInDb = responseData;

            // Get all cities from database and fill cities list
            $.ajax({
                url: "/api/cities",
                method: "GET",
                success: function (responseData) {
                    citiesInDb = responseData;
                    if (responseData.length == 0)
                        $("#ponuda").append("<p>There are no cities in database.</p>");
                    else {
                        if (cityFilter !== null)
                            responseData = responseData.filter(city => city.name === cityFilter);
                        responseData.forEach(function (city) {
                            // Add new card for each city in database
                            $("#ponuda").append(`
                                <div id="card">
                                    <div class="row ">
                                        <div class="picbox">
                                            <div class="pic"></div>
                                        </div>
                                        <div class="descriptionBox">
                                            <div class="card-block px-3">
                                                <h2 class="card-title">${city.name}</h2>
                                                <p class="cardText">${city.description}</p>
                                                <button class="btn btn-primary" onclick="details(${city.id})">Read More</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            `);

                            // Filter feedbacks based on which category button is toggled
                            var cityFeedbacks = feedbacksInDb.filter(
                                feedback => feedback.city.id ===
                                    city.id &&
                                    (category === 'All' ?
                                        true :
                                        feedback.tag.name === category
                                    )
                            );
                            // Add wrapper for feedbacks for current city
                            $('#ponuda').append(`<div id="feedbackWrapper${city.id}" class="card-f">`);
                            var feedbacksContainer = $('#feedbackWrapper' + city.id);
                            loadFeedbackCards(feedbacksContainer, cityFeedbacks);
                            $('#ponuda').append('</div><hr/>');
                        });
                    }

                    // Focus on cities list
                    $('html,body').animate(
                        {
                            scrollTop: $("#ponuda").offset().top - 64
                        },
                        'slow'
                    );
                },
                // If reading cities from database failed
                error: function () {
                    alert('Something wrong happend.');
                }
            });

        },
        // If reading feedbacks from database failed
        error: function () {
            alert('Something wrong happend.');
        }
    });

}

function loadFeedbackCards(feedbacksContainer, feedbacks) {
    console.log(feedbacksContainer, feedbacks);
    // Add feedbacks in wrapper
    feedbacks.forEach(function (feedback) {
        var time = new Date(feedback.time);
        feedbacksContainer.append(`
            <div class="card radius shadowDepth1">
                <div class="card__content card__padding">
                    <div class="card__meta">
                        <a href="#">${feedback.tag.name}</a>
                        <time>${time.toLocaleDateString()}</time>
                    </div>
                    <article class="card__article">
                        <h5><a href="#">${feedback.title}</a></h5>
                        <p>${feedback.comment}</p>
                    </article>
                </div>
                <hr>
                <div class="card__action">
                    <div class="card__author">
                        <img src="http://lorempixel.com/40/40/sports/" alt="user">
                        <div class="card__author-content">
                            By: <a href="#">${feedback.user.firstName + ' ' + feedback.user.lastName}</a>
                            <p>Ocena : ${feedback.rating}</p>
                        </div>
                    </div>
                </div>
            </div>
        `);
    });
}