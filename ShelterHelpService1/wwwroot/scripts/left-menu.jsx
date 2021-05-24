class LeftMenuItem extends React.Component {
    render() {
        return <div><a class="link" href={this.props.href != undefined ? this.props.href : "#"}>
            <img src={"images/" + this.props.file} className="link-icon" />{this.props.title}
        </a></div>;
    }
}

ReactDOM.render(
    <div id="left-menu">
        <LeftMenuItem title="Лента событий" file="events feed.png" />
        <LeftMenuItem title="Наши приюты" file="house.png" />
        <LeftMenuItem title="Сообщения" file="email.png" />
        <LeftMenuItem title="Уведомления" file="bell1.png" />
        <LeftMenuItem title="Сделать пост" file="megaphone.png" />
    </div>,
    document.getElementsByClassName("main-left-column")[0]
);