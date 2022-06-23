import React, { useState, useEffect } from "react";
import TeaCard from "../Components/TeaCard";
import { getTea } from "../Data/TeaData";

export default function Tea() {
  const [teas, setTeas] = useState([]);

  useEffect(() => {
    let isMounted = true;
    if (isMounted) {
      getTea().then(setTeas);
    }
    return () => {
      isMounted = false;
    };
  }, []);

  return (
    <div className="body">
      <div className="title">
        <strong>
        Teas
        </strong>
        <hr className="hr" />
      </div>
      <img
        className="img"
        src="https://www.verywellhealth.com/thmb/ZGs7ufUg-ohsUzQrZZ_Lfbfavns=/1989x1492/smart/filters:no_upscale()/GettyImages-693893647-588d21e413dd411cb1f2b0a0ea3e02da.jpg"
        alt="tea-img"
      />
      <div className="div-body">
        <div className="cards">
          {teas.map((tea) => (
            <TeaCard
              key={tea.id}
              setTeas={setTeas}
              tea={tea}
            />
          ))}
        </div>
      </div>
    </div>
  );
}
