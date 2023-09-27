
$('#search-button').on('click', function (event) {
    console.log("click");
    // loadMore();
    
    // checkboxes = $('.checkbox-type:checked').val();
    
    // var checkboxes = document.getElementsByName('checkbox-type');
    // var checkboxesChecked = [];
    // // loop over them all
    // for (var i=0; i<checkboxes.length; i++) {
    //     // And stick the checked ones onto an array...
    //     if (checkboxes[i].checked) {
    //         checkboxesChecked.push(checkboxes[i]);
    //     }
    // }
    let checkboxesChecked = [];
    let checkboxString = '';
    let checkedBoxes = document.querySelectorAll('input[class=checkbox-type]:checked');
    for (let i = 0; i < checkedBoxes.length; i++){
        checkboxesChecked.push(checkedBoxes[i].id);
        
    }
    checkboxString = checkboxesChecked.join(",");
    console.log(checkboxesChecked);
    let inputField = $('#search-field').val();
    console.log(inputField);
    console.log(inputField.length);
    if (checkboxString != null && checkboxString.length > 0 && inputField.length > 0){
        console.log("why here???")
        loadMoreFull(inputField, checkboxString);
    }
    else if (checkboxString != null && checkboxString.length > 0){
        loadMoreCheckboxes(checkboxString);
    }
    else if (inputField != null && inputField.length > 0){
        loadMoreName(inputField);
    }
    else {
        loadMoreEmpty();
    }
})

function loadMoreFull(name, checkboxes){
    $.ajax({
        type: "GET",
        url: `/get-articles/search?name=${name}&checkboxes=${checkboxes}`,
        dataType: "json",
        success: function(res) {
            console.log(res);

            displayArticlesSearch(res);
        }
    })
}

function loadMoreCheckboxes(checkboxes){
    $.ajax({
        type: "GET",
        url: `/get-articles/search-checkboxes?checkboxes=${checkboxes}`,
        dataType: "json",
        success: function(res) {
            console.log(res);

            displayArticlesSearch(res);
        }
    })
}

function loadMoreName(name){
    $.ajax({
        type: "GET",
        url: `/get-articles/search-name?name=${name}`,
        dataType: "json",
        success: function(res) {
            console.log(res);

            displayArticlesSearch(res);
        }
    })
}

function loadMoreEmpty(){
    $.ajax({
        type: "GET",
        url: `/get-articles?loadPerClick=${3}&loaded=${0}`,
        dataType: "json",
        success: function(res) {
            console.log(res);
            displayArticles(res);
        }
    })
}

function displayArticlesSearch(articles) {
    let htmlTags = "";
    // htmlTags += "<div class=\"main-div\">";
    let i = 0;
    let article;
    for (article of articles) {
        i++;
        htmlTags += `
        <div class="article-in-list">
            <div class="row">
                <img class="article-in-list-image" src="${article["image"]}">
                <div>
                    <h2><a href="/Article/${article["id"]}">${article["title"]}</a></h2>
                    <p>${article["annotation"]}</p>
                </div>
            </div>
            <div>
                <p>Теги: ${article["tags"]}</p>
            </div>
        </div>`
    }

    // htmlTags += `</div>`
    
    // console.log(htmlTags);
    // console.log($('#article-list').html);
    $('#render-body-div').html(htmlTags);
    // console.log($('#article-list').innerHTML);

    // const div = document.getElementById("article-list");
    // div.innerHTML += htmlTags;
}