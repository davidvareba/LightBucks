import axios from "axios";

const baseUrl = "https://localhost:7150/api";

const getCoffee = () =>
  new Promise((resolve, reject) => {
    axios
        .get(`${baseUrl}/Coffees`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });

const getCoffeeById = (id) =>
  new Promise((resolve, reject) => {
    axios
        .get(`${baseUrl}/Coffees/Coffee/${id}`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });

const createCoffee = (coffeeObj) => 
 new Promise((resolve, reject) => {
   axios
       .post(`${baseUrl}/Coffees`, coffeeObj)
    .then((response) => resolve(response.data))
    .catch(reject);
 })
  const getCoffeeByUserUid = (uid) =>
  new Promise((resolve, reject) => {
    axios
        .get(`${baseUrl}/Coffees/Coffee/user/${uid}`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });

const deleteCoffee = (id) =>
  new Promise((resolve, reject) => {
    console.warn(baseUrl);
    axios
        .delete(`${baseUrl}/Coffees/Coffee/${id}`)
      .then(() => getCoffee().then(resolve))
      .catch(reject);
  });

const updateCoffee = (coffeeObj) => 
 new Promise((resolve, reject) => {
   axios
       .patct(`${baseUrl}/Coffees/Coffee`, coffeeObj)
    .then((response) => resolve(response.data))
    .catch(reject);
 })

export { updateCoffee, getCoffee, getCoffeeById, createCoffee, deleteCoffee, getCoffeeByUserUid };