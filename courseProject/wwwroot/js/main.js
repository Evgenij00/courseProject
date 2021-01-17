const menuBtn = document.querySelector('#menu-btn')
const sidebar = document.querySelector('#sidebar')

menuBtn.addEventListener('click', event => {
    event.preventDefault()
    sidebar.classList.toggle('d-none')
})
