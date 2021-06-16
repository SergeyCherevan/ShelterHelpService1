
class CommentsBlock extends React.Component {

    render() {

        let parser = new DOMParser();
        let xmlDoc = parser.parseFromString(this.props.xmlComments, "text/xml");

        let innerXml = <></>;

        for (let comment of xmlDoc.getElementsByTagName('Comment')) {

            innerXml =
                <>
                    {innerXml}

                    <div className="one-comment-block">

                        <div className="avatar-part">

                            <h6>
                                <a href={"/Content/User/" + comment.getAttribute("AuthorName")} >
                                    {comment.getAttribute("AuthorName")}
                                </a>
                            </h6>

                            <img src={"/users-images/" + comment.getAttribute("AuthorAvatar")} />

                        </div>

                        <div className="content-part">

                        {
                            comment.getAttribute("Category") === "content" ?
                                <p style={{ display: "inline-block" }}>{comment.getElementsByTagName('Content')[0].textContent}</p> :
                                <h2 style={{
display: "inline-block",

background: `linear-gradient( to right, #eaa221, #eaa221 ${comment.getAttribute("Rating") * 10}%, #888 ${comment.getAttribute("Rating") * 10}%, #888 100%)`,
WebkitBackgroundClip: 'text',
WebkitTextFillColor: 'transparent'
                                }}>★★★★★</h2>
                        }

                        </div>

                    </div>
                </>;
        }

        let returnBlock = React.createElement('div', { id: "comments-block-" + this.props.id, className: "comments-block" }, innerXml);

        return returnBlock;
    }
}