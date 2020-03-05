(function (renderer) {
    'use strict';

    const preview = document.getElementById('preview');
    if (!preview) {
        console.error('Preview element element not found!');
        return;
    }

    const editorTextarea = document.getElementById('editor-textarea');
    if (!editorTextarea) {
        console.error('Editor textarea element not found!');
        return;
    }

    function renderMarkdown() {
        preview.innerHTML = renderer.render(editorTextarea.value);
    }

    renderMarkdown();
    editorTextarea.addEventListener('keyup', renderMarkdown);
    editorTextarea.addEventListener('paste', renderMarkdown);
})(new markdownit().use(markdownitEmoji));