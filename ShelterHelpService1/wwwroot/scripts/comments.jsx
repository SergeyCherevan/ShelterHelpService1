
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

                            {comment.getElementsByTagName('Content')[0].textContent}

                        </div>

                    </div>
                </>;
        }

        let returnBlock = React.createElement('div', { className: "comments-block" }, innerXml);

        return returnBlock;
    }
}