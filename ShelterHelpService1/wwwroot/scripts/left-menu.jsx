class LeftMenuItem extends React.Component {
    render() {

        return (
            <div onClick={ this.props.href != undefined ? () => { document.location.href = this.props.href } : () => {} }>
                <a className="link">
                    <img src={"/images/" + this.props.file} className="link-icon" />{this.props.title}
                </a>
            </div>
        );
    }
}

{
    ReactDOM.render(
        <div id="left-menu">
            <LeftMenuItem title="Лента событий" file="events feed.png" href="/Home/Timeline" />
            <LeftMenuItem title="Наши приюты" file="house.png" />
            <LeftMenuItem title="Пользователи" file="users.png" />
            {
                window.isAuthenticated ?
                <>
                    <LeftMenuItem title="Сообщения" file="email.png" />
                    <LeftMenuItem title="Уведомления" file="bell.png" />
                    <LeftMenuItem title="Сделать пост" file="megaphone.png" />
                </>
                    : ""
            }
        </div>,
        document.getElementsByClassName("main-left-column")[0]
    );
}