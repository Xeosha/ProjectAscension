import { useContext, useCallback } from 'react';
import { InventoryContext } from '../context/InventoryContext';

export const useInventory = () => {
  const { state, dispatch } = useContext(InventoryContext);

  const equipItem = useCallback((heroId, slot, itemId) => {
    dispatch({
      type: 'EQUIP_ITEM',
      payload: { heroId, slot, itemId }
    });
  }, [dispatch]);

  const unequipItem = useCallback((heroId, slot) => {
    dispatch({
      type: 'UNEQUIP_ITEM',
      payload: { heroId, slot }
    });
  }, [dispatch]);

  return {
    // Состояние
    inventory: state.inventory,
    equipments: state.equipments,
    
    // Методы получения данных
    getAvailableItems: useCallback((slot) => {
      return state.inventory.filter(item => {
        const isCorrectType = item.slot === slot;
        const isNotEquipped = !Object.values(state.equipments).some(equipment => 
          Object.values(equipment).includes(item.id)
        );
        return isCorrectType && isNotEquipped;
      });
    }, [state.inventory, state.equipments]),

    getEquippedItem: useCallback((heroId, slot) => {
      const equipment = state.equipments[heroId];
      if (!equipment || !equipment[slot]) return null;
      return state.inventory.find(item => item.id === equipment[slot]);
    }, [state.inventory, state.equipments]),
    
    // Действия
    equipItem,
    unequipItem
  };
};