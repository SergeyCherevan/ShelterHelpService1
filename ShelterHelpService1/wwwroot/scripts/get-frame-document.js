
function getFrameDocument(frame) {
    return frame && (frame.contentDocument || frame.contentWindow || null);
}