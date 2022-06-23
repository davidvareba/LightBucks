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
      .get(`${baseUrl}/Teateas/${id}`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });

const createTea = (teaObj) => 
 new Promise((resolve, reject) => {
   axios
    .post(`${baseUrl}/Teas`, teaObj)
    .then((response) => resolve(response.data))
    .catch(reject);
 })
  const getTeaByUserUid = (uid) =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseUrl}/Tea/user/${uid}`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });

const deleteTea = (id) =>
  new Promise((resolve, reject) => {
    console.warn(baseUrl);
    axios
      .delete(`${baseUrl}/Teas/${id}`)
      .then(() => getTea().then(resolve))
      .catch(reject);
  });

const updateTea = (teaObj) => 
  new Promise((resolve, reject) => {
    axios
     .patch(`${baseUrl}/Tea`, teaObj)
     .then((response) => resolve(response.data))
     .catch(reject);
  })
export { getTea, getTeaById, createTea, deleteTea, getTeaByUserUid, updateTea};