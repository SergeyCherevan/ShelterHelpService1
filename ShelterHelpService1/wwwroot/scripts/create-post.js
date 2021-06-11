
{
    tinymce.init({
        selector: '#create-post-editor',
        toolbar: 'undo redo | styleselect | bold underline italic| alignleft aligncenter alignright alignjustify | outdent indent',
        content_css: '/styles/style.css',
    });

    setTimeout(() => {

        let tinymceIframe = document.getElementById("create-post-editor_ifr");

        let frameDocument = getFrameDocument(tinymceIframe);

        let contentBlock = frameDocument.getElementById("tinymce");

        contentBlock.classList.add('create-post-input-block');

    }, 1000);
}

function getFrameDocument(frame) {
    return frame && (frame.contentDocument || frame.contentWindow || null);
}