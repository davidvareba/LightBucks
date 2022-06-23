import React, { useState } from 'react';
import { CardImg } from 'reactstrap';
import PropTypes from 'prop-types';
import { Button } from 'reactstrap';
import { deleteCoffee, updateCoffee } from '../Data/CoffeeData';

export default function CoffeeCard({ coffee, setCoffee }) {
  const [checked, setChecked] = useState();

  const handleChange = (event) => {
    setChecked(!checked);
    const favcoffee = {
      name: coffee.make,
      descriptions: coffee.descriptions,
      price: coffee.price,
      imageUrl: coffee.imageUrl,
      uid: coffee.uid,
      favorite: event.target.checked,
    };
    updateCoffee(favcoffee).then(setCoffee);
  };

  const handleClick = (method) => {
    if (method === 'delete') {
      deleteCoffee(coffee.id).then(setCoffee);
    }
  };

  return (
    <div>
      <div className="card" style={{ width: '18rem', margin: '10px' }}>
        <CardImg
          alt="Card image"
          src={coffee.imageUrl}
        />
        <div className="card-body">
          <h6 className="card-title">Name: {coffee.name}</h6>
          <hr />
          <p className="card-text">Descriptions: {coffee.descriptions}</p>
          <p className="card-text">Price: {coffee.price}</p>
          <label>
            <input
              type="checkbox"
              checked={coffee.favorite ? 'checked' : ''}
              onChange={handleChange}
            />
            Like this Coffee?
          </label>
          <div className="d-grid gap-2 mt-3">
            <Button to={`/edit/${coffee.firebaseKey}`} className="btn btn-warning btn-block">
              Edit Coffee
            </Button>
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

CoffeeCard.propTypes = {
  coffee: PropTypes.shape(PropTypes.obj).isRequired,
  setCoffee: PropTypes.func.isRequired,
};
