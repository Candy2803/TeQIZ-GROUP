document.querySelector('#nav').addEventListener('click', e => {
    let section_name = e.target.dataset.name
    let element = document.getElementById(section_name)
    element.scrollIntoView({ behavior: "smooth" })
})