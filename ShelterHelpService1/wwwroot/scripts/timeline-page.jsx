
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

        let timelinePost = this.props.timelinePostData;

        let isActual = timelinePost.isActual;

        let date = timelinePost.datePublicating;

        let authorName = timelinePost.authorName;

        return  <div className="post-block">

                    <div className="post-block-header">

                        <h1>{timelinePost.title}</h1>

                        <h6 className="author">автор: <a href={"Content/Users?nick=" + authorName}>{authorName}</a></h6>

                    </div>



                    <div className="post-block-anderheader">

                        <div className="right-part">

                            <h6 className="category">{timelinePost.category}</h6>

                            <h6>
                            {
                                ('0' + date.getHours()).slice(-2) + ":" + 
                                ('0' + date.getMinutes()).slice(-2) + " / " +
                                ('0' + date.getDate()).slice(-2) + "." + 
                                ('0' + date.getMonth()).slice(-2) + "." + 
                                date.getFullYear().toString().slice(-2)
                            }
                            </h6>

                            <h6 className={"is-actual-" + isActual}>{isActual ? "" : "не"} актуально</h6>

                        </div>



                <div className="left-part">{timelinePost.rating} <span className="star">★</span></div>


                    </div>



            <div className="post-block-content" dangerouslySetInnerHTML={{ __html: timelinePost.htmlPage }}></div>



                    <div className="post-block-footer">

                        <button className="interactive-button" id={"see-on-page-button-" + timelinePost.id} >Смотреть на странице</button>

                        <img className="arrow-down" id={"see-more-" + timelinePost.id}
                            src="/images/arrow-down.png"></img>

                        <button className="interactive-button" id={"comment-button-" + timelinePost.id} >Комментировать</button>

                    </div>

                </div>;
    }
}

// Получение данных от сервера

let countOfPosts = 3;

{
    let request = new XMLHttpRequest();

    let url = "/Content/TimelinePosts";

    request.open('GET', url);

    request.setRequestHeader('Content-Type', 'application/json');

    request.addEventListener('readystatechange', () => {

        if (request.readyState === 4 && request.status === 200) {

            showTimeLinePosts(request.response);
        }

    });

    request.send();
}

// Отображение полученных с сервера блоков в ленте новостей

function showTimeLinePosts(jsonResponceText) {
    
    let jsonResponce = JSON.parse(jsonResponceText);

    let mainRightColumn = document.getElementsByClassName("main-right-column")[0];

    for (let postData of jsonResponce) {

        let newPost = document.createElement('div');
        newPost.id = "post-block-" + postData.id;

        ReactDOM.render(
            <PostBlock
                timelinePostData={{
                    id: postData.id,
                    authorName: postData.authorName,
                    title: postData.title,
                    category: window.listOfTimelinePostCategories[postData.category],
                    datePublicating: new Date(postData.datePublicating),
                    isActual: postData.isActual,
                    htmlPage: postData.htmlPage,
                    rating: postData.rating,
                    xmlComments: postData.xmlComments,
                }}>
            </PostBlock>,
            newPost
        );

        mainRightColumn.append(newPost);




        let seeMore = document.getElementById("see-more-" + postData.id);

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