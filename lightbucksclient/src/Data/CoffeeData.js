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
      .get(`${baseUrl}/coffees/coffees/user/${id}`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });

const createCoffee = (coffeeObj) => 
 new Promise((resolve, reject) => {
   axios
    .post(`${baseUrl}/coffees`, coffeeObj)
    .then((response) => resolve(response.data))
    .catch(reject);
 })
  const getCoffeeByUserUid = (uid) =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseUrl}/coffee/coffee/user/${uid}`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });

const deleteCoffee = (id) =>
  new Promise((resolve, reject) => {
    console.warn(baseUrl);
    axios
      .delete(`${baseUrl}/coffees/coffees/${id}`)
      .then(() => getCoffee().then(resolve))
      .catch(reject);
  });

export { getCoffee, getCoffeeById, createCoffee, deleteCoffee, getCoffeeByUserUid };