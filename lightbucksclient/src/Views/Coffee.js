import React, { useState, useEffect } from "react";
import CoffeeCard from "../Components/CoffeeCard";
import { getCoffee } from "../Data/CoffeeData";

export default function Coffee() {
  const [coffees, setCoffees] = useState([]);

  useEffect(() => {
    let isMounted = true;
    if (isMounted) {
      getCoffee().then(setCoffees);
    }
    return () => {
      isMounted = false;
    };
  }, []);

  return (
    <div className="body">
      <img
        className="img"
        src="https://upload.wikimedia.org/wikipedia/commons/thumb/4/45/A_small_cup_of_coffee.JPG/1200px-A_small_cup_of_coffee.JPG"
        alt="coffee-img"
      />
      <div className="title">
        Coffees
        <hr className="hr" />
      </div>
      <div className="div-body">
        <div className="cards">
          {coffees.map((coffee) => (
            <CoffeeCard
              key={coffee.id}
              setListings={setCoffees}
              coffee={coffee}
            />
          ))}
        </div>
      </div>
    </div>
  );
}
