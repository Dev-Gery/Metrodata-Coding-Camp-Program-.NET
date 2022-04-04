// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const animals = [
    { name: "garfield", species: "cat", class: { name: "mamalia" } },
    { name: "nemo", species: "fish", class: { name: "invertebrata" } },
    { name: "tom", species: "cat", class: { name: "mamalia" } },
    { name: "garry", species: "cat", class: { name: "mamalia" } },
    { name: "dory", species: "fish", class: { name: "invertebrata" } }
]

console.log(animals);
const OnlyCat = [];
for (var i = 0; i < animals.length; i++) {
    if (animals[i].species == "cat") {
        OnlyCat.push(animals[i]);
    }
    else if (animals[i].species == "fish") {
        animals[i].class.name = "non-mamalia";
    }
}
console.log(animals);
console.log(OnlyCat);