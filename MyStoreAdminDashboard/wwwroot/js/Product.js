    let ingredients = []

    function addToIngredientNames() {
        let singleIngredient = document.getElementById("ing")
    ingredients.push(singleIngredient.value)
    let ingContainer = document.getElementById("ing-container")
    let ingText = document.createElement("p")
    ingText.innerHTML = singleIngredient.value
    ingContainer.appendChild(ingText)
    singleIngredient.value = ""
    }

    function createProduct(e) {
        e.preventDefault()
        let data = new FormData(e.target);

        ingredients.forEach(x => {
        let ingredient = {
        name: x,
    productId: 0,
            }

    data.ingredients.push(ingredient)
        });

    axios.post(`/Product/Create`, data)
    .then(function (response) {
        console.log('yeeey')
    })
            .catch(error => {
        console.log(error);
            })
    }