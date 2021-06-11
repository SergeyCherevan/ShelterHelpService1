
{
    let createPostEditor = document.getElementById("create-post-editor");

    ClassicEditor
        .create(createPostEditor)
        .catch(err => console.error(err));
}