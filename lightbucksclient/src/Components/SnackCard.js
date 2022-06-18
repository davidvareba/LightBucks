import React, { useState } from 'react';
import { CardImg } from 'reactstrap';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import { Button } from 'reactstrap';
import { deleteSnack, updateSnack } from '../Data/SnackData';

export default function SnackCard({ snack, setSnack }) {
  const [checked, setChecked] = useState();

  const handleChange = (event) => {
    setChecked(!checked);
    const favsnack = {
      firebaseKey: snack.firebaseKey,
      name: snack.make,
      descriptions: snack.descriptions,
      price: snack.price,
      imageUrl: snack.imageUrl,
      uid: snack.uid,
      favorite: event.target.checked,
    };
    updateSnack(favsnack).then(setSnack);
  };

  const handleClick = (method) => {
    if (method === 'delete') {
      deleteSnack(snack.id).then(setSnack);
    }
  };

  return (
    <div>
      <div className="card" style={{ width: '18rem', margin: '10px' }}>
        <CardImg
          alt="Card image"
          src={snack.imageUrl}
        />
        <div className="card-body">
          <h6 className="card-title">Name: {snack.name}</h6>
          <hr />
          <p className="card-text">Descriptions: {snack.descriptions}</p>
          <p className="card-text">Price: {snack.price}</p>
          <label>
            <input
              type="checkbox"
              checked={snack.favorite ? 'checked' : ''}
              onChange={handleChange}
            />
            Like this Snack?
          </label>
          <Link
              type="button"
              className="btn btn-primary"
              to={`/coffee/${snack.id}`}
            >
              Details
        </Link>
          <div className="d-grid gap-2 mt-3">
            <Link to={`/edit/${snack.firebaseKey}`} className="btn btn-warning btn-block">
              Edit Snack
            </Link>
            <Button
              onClick={() => handleClick('delete')}
              className="btn btn-danger"
              type="button"
            >
              DELETE
            </Button>
          </div>
        </div>
      </div>
    </div>
  );
}

SnackCard.propTypes = {
  tea: PropTypes.shape(PropTypes.obj).isRequired,
  setTea: PropTypes.func.isRequired,
};
