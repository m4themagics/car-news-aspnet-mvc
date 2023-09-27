let loadedParams = []

$('#brand-parent-tag').on('click', function (event) {
    console.log('it');
    loadTags(1, 'brand-tags');
});

function loadTags(parentTagId, divName) {
    if (loadedParams.includes(divName)) {
        return;
    }
    $.ajax({
        type: "GET",
        url: "/tags",
        dataType: "json",
        success: function(res) {
            console.log(res);
            displayTags(res, parentTagId, divName);    
        },
    })
}

function displayTags(tags, parentTagId, divName) {
    var htmlTags = ""
    for (tag of tags) {
        if (tag["parentId"] === parentTagId){
            htmlTags += `
            <label class="display-inline">
                <input class="checkbox-type" type="checkbox" id="${tag["name"]}" value="${tag["id"]}">${tag["name"]}
            </label>`
        }
    }
    $('#' + divName).html(htmlTags);
    // $('#brand-tags').html(htmlTags);
    // const div = document.getElementById(divName);
    // div.innerHTML = htmlTags;
}