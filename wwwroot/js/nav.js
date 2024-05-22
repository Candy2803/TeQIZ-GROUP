let navBar = document.querySelector('#nav-bar')
let navCont = document.getElementById('nav')
let links = document.querySelectorAll('#link')

navBar.addEventListener('click', e => {
    navCont.classList.toggle('on')
})

links.forEach(link => {
    link.addEventListener('click', () => {
        navCont.classList.toggle('on')
    })
})