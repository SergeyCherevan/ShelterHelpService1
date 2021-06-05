
/* Данный скрипт определяет отрисовку главной страницы - Ленты событий,
 * которая отображается по адрессу: /Home/Index */



// Создание заголовка сраницы

{
    ReactDOM.render(
        <h1>Лента событий</h1>,
        document.getElementsByClassName("main-right-column")[0]
    );
}

// Класс новостного блока

class PostBlock extends React.Component {
    render() {
        return  <div className="post-block">

                    <div className="post-block-header">

                        <h1>{this.props.title}</h1>

                        <h6 className="author">автор: <a href="#">{this.props.author}</a></h6>

                    </div>

                    <div className="post-block-content" dangerouslySetInnerHTML={{ __html: this.props.content }}></div>

                    <div className="post-block-footer">

                        <button className="interactive-button" id={"see-on-page-button-" + this.props.number} >Смотреть на странице</button>

                        <img className="arrow-down" id={"see-more-" + this.props.number}
                            src="/images/arrow-down.png"></img>

                        <button className="interactive-button" id={"comment-button-" + this.props.number} >Комментировать</button>

                    </div>

                </div>;
    }
}

// Создание 3-ёх новостных блоков

let countOfPosts = 3;
{
    let mainRightColumn = document.getElementsByClassName("main-right-column")[0];

    for (let i = 0; i < countOfPosts; i++) {

        let newPost = document.createElement('div');
        newPost.id = "post-block-" + i;

        let loremIpsum = `
            <img src="/images/dog-on-form.jpg" style="float: left; width: 30vw; margin: 0 1vw 1vw 0"></img>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            <br><br>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            <br><br>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            `;

        ReactDOM.render(
            <PostBlock number={i} title="Барсик ищет хозяина" author="Марина"
                content={loremIpsum}></PostBlock>,
            newPost
        );

        mainRightColumn.append(newPost);




        let seeMore = document.getElementById("see-more-" + i);

        seeMore.addEventListener('click', clickSeeMore);

        function clickSeeMore() {

            newPost.firstChild.className = "post-block see-more";

            seeMore.src = "/images/arrow-up.png";

            seeMore.removeEventListener('click', clickSeeMore);
            seeMore.addEventListener('click', clickSeeCompact);
        };

        function clickSeeCompact() {

            newPost.firstChild.className = "post-block";

            seeMore.src = "/images/arrow-down.png";

            seeMore.removeEventListener('click', clickSeeCompact);
            seeMore.addEventListener('click', clickSeeMore);
        }
    }
}