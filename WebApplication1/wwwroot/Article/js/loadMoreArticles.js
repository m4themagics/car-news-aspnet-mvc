const loadPerClick = 3;
let loaded = 0;

$(document).ready(function () {
    console.log("ready");
    if (loaded === 0)
        loadMore();
});

$('#load-more').on('click', function (event) {
    console.log("click");
    loadMore();
})

function loadMore(){
    $.ajax({
        type: "GET",
        url: `/get-articles?loadPerClick=${loadPerClick}&loaded=${loaded}`,
        dataType: "json",
        success: function(res) {
            console.log(res);
            displayArticles(res);
        }
    })
}

function displayArticles(articles) {
    let htmlTags = "";
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
    loaded += i;
    // console.log(htmlTags);
    // console.log($('#article-list').html);
    $('#article-list').append(htmlTags);
    // console.log($('#article-list').innerHTML);
    
    // const div = document.getElementById("article-list");
    // div.innerHTML += htmlTags;
}