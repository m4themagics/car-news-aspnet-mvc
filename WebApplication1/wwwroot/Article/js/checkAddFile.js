let countTextArea = 1;
let countImages = 1;
let input;
let dateEntered;

document.getElementById("article-date").addEventListener("change", function () {
    input = this.value;
    dateEntered = new Date(input);
});

function addTextArea() {
    let parent = document.getElementById("main-part");

    let label = document.createElement("label");
    label.textContent = "Введите текст";
    label.className = "add-lable";
    label.setAttribute("for", "article-textblock-" + countTextArea);
    parent.appendChild(label);

    let div = document.createElement("div");
    div.className = "add-element";
    div.id = "add-element-textarea-" + countTextArea;
    parent.appendChild(div);

    let input = document.createElement("textarea");
    input.className = "add-input";
    input.id = "article-textblock-" + countTextArea;
    input.setAttribute("rows", "5");
    div.appendChild(input);

    countTextArea++;
}

function addImage() {
    let parent = document.getElementById("main-part");

    let label = document.createElement("label");
    label.textContent = "Выберите картинку";
    label.className = "add-lable";
    label.setAttribute("for", "article-image-" + countImages);
    parent.appendChild(label);

    let div = document.createElement("div");
    div.className = "add-element";
    div.id = "add-element-image-" + countImages;
    parent.appendChild(div);

    let input = document.createElement("input");
    input.className = "add-input";
    input.id = "article-image-" + countImages;
    input.setAttribute("type", "file");
    div.appendChild(input);

    countImages++;
}

function checkForm() {
    const articleName = document.getElementById("article-name");
    if (articleName.value == "") {
        alert("Название статьи не должно быть пустым");
        return;
    }

    const articleMainPicture = document.getElementById("article-main-picture");
    if (articleMainPicture.value == "") {
        alert("Основная картинка не может быть пустой");
        return;
    }
    let articleMainPictureExtension = articleMainPicture.value.split('.').pop();
    articleMainPictureExtension = articleMainPictureExtension.toLowerCase();
    if (articleMainPictureExtension != "jpg" && articleMainPictureExtension != "png" && articleMainPictureExtension != "jpeg") {
        alert("Основная картинка должна быть формата jpg, jpeg или png");
        return;
    }
    const image = new Image();
    image.onload = function() {
        if (this.width > 2000 || this.hight > 2000 || this.width < 400 || this.hight < 400) {
            alert("Размеры картинки не должны быть меньше 400 и больше 2000 пикселей");
            return;
        }
    }
    const file = articleMainPicture.files[0];
    image.src = URL.createObjectURL(file);

    const articleAnnotation = document.getElementById("article-annotation");
    if (articleAnnotation.value.length < 10 || articleAnnotation.value.length > 200) {
        alert("Аннотация статьи не должна быть пустой, быть меньше 10 и больше 200 символов");
        return;
    }

    const articleTags = document.getElementById("article-tags");
    let selected = [];
    for (let option of articleTags.options)
    {
        if (option.selected) {
            selected.push(option.value);
        }
    }
    if (selected.length == 0) {
        alert("Нельзя создать статью без тегов");
        return;
    }

    const articleAuthor = document.getElementById("article-author");
    if (articleAuthor.value == "" || !/^[A-Za-zА-Яа-я- ]+$/.test(articleAuthor.value)) {
        alert("Необходимо корректно вписать автора статьи");
        return;
    }

    const articleDate = document.getElementById("article-date");
    let dateEntered = new Date(input);
    let curDate = new Date();
    if (articleDate.value == null || articleDate.value == "" || dateEntered > curDate) {
        alert("Необходимо указать дату написания статьи, которая меньше текущей даты");
        return;
    }
}