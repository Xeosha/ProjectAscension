import { useState } from "react";

export const useEquipment = (initialEquipment) => {
  const [equippedItems, setEquippedItems] = useState(initialEquipment);

  const updateEquipment = (category, item) => {
    setEquippedItems((prev) => ({
      ...prev,
      [category]: item,
    }));
  };

  const clearEquipment = (category) => {
    setEquippedItems((prev) => ({
      ...prev,
      [category]: null,
    }));
  };

  return { equippedItems, updateEquipment, clearEquipment };
};
