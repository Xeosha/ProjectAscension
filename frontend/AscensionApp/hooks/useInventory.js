import { useState } from "react";

export const useInventory = (initialInventory) => {
  const [inventory, setInventory] = useState(initialInventory);

  const filterByCategory = (category) => inventory.filter((item) => item.category === category);

  const equipItem = (itemId) => {
    setInventory((prevInventory) =>
      prevInventory.map((item) =>
        item.id === itemId ? { ...item, isEquipped: true } : { ...item, isEquipped: false }
      )
    );
  };

  const unequipItem = (itemId) => {
    setInventory((prevInventory) =>
      prevInventory.map((item) => (item.id === itemId ? { ...item, isEquipped: false } : item))
    );
  };

  return { inventory, filterByCategory, equipItem, unequipItem };
};
