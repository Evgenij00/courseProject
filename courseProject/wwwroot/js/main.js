const menuBtn = document.querySelector('#menu-btn')
const sidebar = document.querySelector('#sidebar')

menuBtn.addEventListener('click', event => {
    event.preventDefault()
    sidebar.classList.toggle('d-none')
})




//Скрипт для страницы "account.html"

const cards = document.querySelector('#cards')
const myTests = document.querySelector('#my-tests')
const btnCards = document.querySelector('#btn-cards')
const btnMyTests = document.querySelector('#btn-my-tests')

btnCards.addEventListener('click', event => {
    if (cards.classList.contains('d-none')) {
        cards.classList.toggle('d-none')
        myTests.classList.toggle('d-none')
    }
})

btnMyTests.addEventListener('click', event => {
    if (myTests.classList.contains('d-none')) {
        myTests.classList.toggle('d-none')
        cards.classList.toggle('d-none')
    }
})

const setting1 = document.querySelector('#setting1')
const setting2 = document.querySelector('#setting2')
const btnSetting1 = document.querySelector('#btn-setting1')
const btnSetting2 = document.querySelector('#btn-setting2')

btnSetting1.addEventListener('click', event => {
    if (!setting1.classList.contains('d-none')) {
        setting1.classList.toggle('d-none')
    } else if (setting1.classList.contains('d-none') && !setting2.classList.contains('d-none')) {
        setting1.classList.toggle('d-none')
        setting2.classList.toggle('d-none')
    } else if (setting1.classList.contains('d-none') && setting2.classList.contains('d-none')) {
        setting1.classList.toggle('d-none')
    }
})

btnSetting2.addEventListener('click', event => {
    if (!setting2.classList.contains('d-none')) {
        setting2.classList.toggle('d-none')
    } else if (!setting1.classList.contains('d-none') && setting2.classList.contains('d-none')) {
        setting1.classList.toggle('d-none')
        setting2.classList.toggle('d-none')
    } else if (setting1.classList.contains('d-none') && setting2.classList.contains('d-none')) {
        setting2.classList.toggle('d-none')
    }
})
