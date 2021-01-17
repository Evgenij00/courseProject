const menuBtn = document.querySelector('#menu-btn')
const sidebar = document.querySelector('#sidebar')

menuBtn.addEventListener('click', event => {
    event.preventDefault()
    sidebar.classList.toggle('d-none')
})


//Скрипт для страницы "account.html"

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
