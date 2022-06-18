import axios from "axios";

const baseUrl = "https://localhost:7150/api";

const getTea = () =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseUrl}/Teas`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });

const getTeaById = (id) =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseUrl}/teas/teas/user/${id}`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });

const createTea = (teaObj) => 
 new Promise((resolve, reject) => {
   axios
    .post(`${baseUrl}/teas`, teaObj)
    .then((response) => resolve(response.data))
    .catch(reject);
 })
  const getTeaByUserUid = (uid) =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseUrl}/tea/tea/user/${uid}`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });

const deleteTea = (id) =>
  new Promise((resolve, reject) => {
    console.warn(baseUrl);
    axios
      .delete(`${baseUrl}/teas/teas/${id}`)
      .then(() => getTea().then(resolve))
      .catch(reject);
  });

export { getTea, getTeaById, createTea, deleteTea, getTeaByUserUid };