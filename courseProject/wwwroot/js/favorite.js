const cards = document.querySelector('#cards')

cards.addEventListener('click', event => {

    if (event.target.classList.contains('fa-heart')) {
        event.preventDefault()

        let test = event.target.parentElement
        let testId = test.dataset.testId
        let isFavorite;

        if (!test.classList.contains('isFavorite')) {
            isFavorite = true;
        } else {
            isFavorite = false;
        }

        let url = '/Test/Favorite/?testId=' + testId + '&isFavorite=' + isFavorite;
        fetch(url)

        test.classList.toggle('isFavorite')
    }
}) 