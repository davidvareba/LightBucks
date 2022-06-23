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
        src=""
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
              setCoffees={setCoffees}
              coffee={coffee}
            />
          ))}
        </div>
      </div>
    </div>
  );
}
