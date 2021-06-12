
{
    tinymce.init({
        selector: '#redact-account-html-editor',
        toolbar: 'undo redo | styleselect | bold underline italic| alignleft aligncenter alignright alignjustify | outdent indent',
        content_css: '/styles/style.css',
    });

    setTimeout(() => {

        let tinymceIframe = document.getElementById("redact-account-html-editor_ifr");

        let frameDocument = getFrameDocument(tinymceIframe);

        let contentBlock = frameDocument.getElementById("tinymce");

        contentBlock.classList.add('redact-account-html-editor-input-block');

    }, 1000);
}