import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import PropTypes from "prop-types";
import { createCoffee, getCoffee } from '../Data/CoffeeData';

const initialState = {
    name: '',
    price: 0,
    descriptions: '',
    imageUrl: '',
}

export default function CoffeeForm(coffee = {}) {
    const [formInput, setFormInput] = useState(initialState);
    let navigation = useNavigate();

    useEffect(() => {
        if (coffee.id) {

            setFormInput({
                name: coffee.name,
                price: Number(coffee.price),
                descriptions: coffee.descriptions,
                imageUrl: coffee.imageUrl,
            });
        }
    }, [coffee]);


    const handleChange = (e) => {
        setFormInput((prevState) => ({
            ...prevState,
            [e.target.id]: e.target.value,
        }));
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        console.warn(formInput);
        const newObject = {
            name: formInput.name,
            price: Number(formInput.price),
            Descriptions: formInput.descriptions,
            ImgUrl: formInput.imageUrl,
        }
        console.warn(newObject);
        createCoffee(newObject).then(getCoffee().then(navigation('/coffee', { replace: true })))
    }

    return (
        <form className='form-body' onSubmit={handleSubmit}>
            <div className='form-group'>
                <label className='form-label' htmlFor="name">
                    Name:
                </label>
                <input type="text" id="name" className='form-input' value={formInput.name || ""} onChange={handleChange} />
            </div>
            <div className='form-group'>
                <label className='form-label' htmlFor="price">
                    Price:
                </label>
                <input type="number" id="price" className='form-input' value={formInput.price || ""} onChange={handleChange} />
            </div>
            <div className='form-group'>
                <label className='form-label' htmlFor="descriptions">
                    Descriptions:
                </label>
                <input type="text" id="descriptions" className='form-input' value={formInput.descriptions || ""} onChange={handleChange} />
            </div>
            <div className='form-group'>
                <label className='form-label' htmlFor="imageUrl">
                    ImageUrl:
                </label>
                <input type="text" id="imageUrl" className='form-input' value={formInput.imageUrl || ""} onChange={handleChange} />
            </div>
            <input type="submit" className='form-btn' value="Submit" />
        </form>
    )
}

CoffeeForm.Proptype = {
    coffee: PropTypes.shape(PropTypes.obj).isRequired,
    setCoffee: PropTypes.func.isRequired
}