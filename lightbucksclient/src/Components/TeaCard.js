import React, { useState } from 'react';
import { CardImg } from 'reactstrap';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import { Button } from 'reactstrap';
import { deleteTea, updateTea } from '../Data/TeaData';

export default function TeaCard({ tea, setTea }) {
  const [checked, setChecked] = useState();

  const handleChange = (event) => {
    setChecked(!checked);
    const favtea = {
      firebaseKey: tea.firebaseKey,
      name: tea.make,
      descriptions: tea.descriptions,
      price: tea.price,
      imageUrl: tea.imageUrl,
      uid: tea.uid,
      favorite: event.target.checked,
    };
    updateTea(favtea).then(setTea);
  };

  const handleClick = (method) => {
    if (method === 'delete') {
      deleteTea(tea.id).then(setTea);
    }
  };

  return (
    <div>
      <div className="card" style={{ width: '18rem', margin: '10px' }}>
        <CardImg
          alt="Card image"
          src={tea.imageUrl}
        />
        <div className="card-body">
          <h6 className="card-title">Name: {tea.name}</h6>
          <hr />
          <p className="card-text">Descriptions: {tea.descriptions}</p>
          <p className="card-text">Price: {tea.price}</p>
          <label>
            <input
              type="checkbox"
              checked={tea.favorite ? 'checked' : ''}
              onChange={handleChange}
            />
            Like this Coffee?
          </label>
          <Link
              type="button"
              className="btn btn-primary"
              to={`/coffee/${tea.id}`}
            >
              Details
        </Link>
          <div className="d-grid gap-2 mt-3">
            <Link to={`/edit/${tea.firebaseKey}`} className="btn btn-warning btn-block">
              Edit Coffee
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

TeaCard.propTypes = {
  tea: PropTypes.shape(PropTypes.obj).isRequired,
  setTea: PropTypes.func.isRequired,
};
