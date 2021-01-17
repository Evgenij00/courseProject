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

const btnChangeEmail = document.querySelector('#btn-change-email')
const btnChangePassword = document.querySelector('#btn-change-password')
const boxChangeEmail = document.querySelector('#box-change-email')
const boxChangePassword = document.querySelector('#box-change-password')

btnChangeEmail.addEventListener('click', event => {
    boxChangeEmail.classList.toggle('d-none')
})

btnChangePassword.addEventListener('click', event => {
    boxChangePassword.classList.toggle('d-none')
}) 