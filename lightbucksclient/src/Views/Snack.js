import React, { useState, useEffect } from "react";
import SnackCard from "../Components/SnackCard";
import { getSnack } from "../Data/SnackData";

export default function Snack() {
  const [snacks, setSnacks] = useState([]);

  useEffect(() => {
    let isMounted = true;
    if (isMounted) {
      getSnack().then(setSnacks);
    }
    return () => {
      isMounted = false;
    };
  }, []);

  return (
    <div className="body">
      <img
        className="img"
        src="https://www.mcdonalds.com/is/image/content/dam/usa/nfl/nutrition/items/hero/desktop/t-mcdonalds-Sausage-Egg-Cheese-McGriddles.jpg"
        alt="snacks-img"
      />
      <div className="title">
        Snacks
        <hr className="hr" />
      </div>
      <div className="div-body">
        <div className="cards">
          {snacks.map((snack) => (
            <SnackCard
              key={snack.id}
              setSnacks={setSnacks}
              snack={snack}
            />
          ))}
        </div>
      </div>
    </div>
  );
}
