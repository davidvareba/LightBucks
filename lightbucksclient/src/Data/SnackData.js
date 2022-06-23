import axios from "axios";

const baseUrl = "https://localhost:7150/api";

const getSnack = () =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseUrl}/Snacks`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });

const getSnackById = (id) =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseUrl}/snacks/snacks/user/${id}`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });

const createSnack = (snackObj) => 
 new Promise((resolve, reject) => {
   axios
    .post(`${baseUrl}/snacks`, snackObj)
    .then((response) => resolve(response.data))
    .catch(reject);
 })
  const getSnackByUserUid = (uid) =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseUrl}/snack/snack/user/${uid}`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });

const deleteSnack = (id) =>
  new Promise((resolve, reject) => {
    console.warn(baseUrl);
    axios
      .delete(`${baseUrl}/snacks/snacks/${id}`)
      .then(() => getSnack().then(resolve))
      .catch(reject);
  });

const updateSnack = (snackObj) => 
  new Promise((resolve, reject) => {
    axios
     .patch(`${baseUrl}/snacks`, snackObj)
     .then((response) => resolve(response.data))
     .catch(reject);
  })
export { getSnack, getSnackById, createSnack, deleteSnack, getSnackByUserUid, updateSnack };