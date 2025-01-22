import { createContext, useReducer } from 'react';
import { IMAGES } from "../constants/constants";

const initialState = {
  inventory: [
    {
      id: 'sword1',
      name: 'Steel Sword',
      type: 'weapon',
      power: 100,
      image: IMAGES.heroWeapon,
      icon: 'shield',
      equippedBy: null
    },
    {
      id: 'sword2',
      name: 'Chain Mail',
      type: 'weapon',
      power: 50,
      image: IMAGES.heroWeapon,
      icon: 'shield',
      equippedBy: null
    },
    {
      id: 'sword3',
      name: 'Steel Helmet',
      type: 'weapon',
      power: 30,
      image: IMAGES.heroWeapon,
      icon: 'shield',
      equippedBy: null
    }
  ],
  equipments: {
    'hero1': {
      baseImage: IMAGES.heroAnim,
      weapon: null,
    },
    'hero2': {
      baseImage: IMAGES.heroAnim,
      weapon: null,
    },
    'hero3': {
      baseImage: IMAGES.heroAnim,
      weapon: null,
    }
  },
  isLoading: false,
  error: null
};

const inventoryReducer = (state, action) => {

  console.log('Reducer Action:', action.type);
  console.log('Reducer Action:', action.payload)
  console.log('Previous State:', state);

  switch (action.type) {
    case 'EQUIP_ITEM': {
      // Находим предмет в инвентаре
      const itemToEquip = state.inventory.find(item => item.id === action.payload.itemId);

      console.log('Item to equip:', itemToEquip);
      
      if (!itemToEquip) return state;
      
      console.log(2);

      return {
        ...state,
        inventory: state.inventory.map(item => 
          item.id === action.payload.itemId
            ? { ...item, equippedBy: action.payload.heroId }
            : item
        ),
        equipments: {
          ...state.equipments,
          [action.payload.heroId]: {
            ...state.equipments[action.payload.heroId],
            // Сохраняем изображение предмета вместо ID
            [action.payload.slot]: itemToEquip.image
          }
        }
      };
    }

    case 'UNEQUIP_ITEM': {
      const { heroId, slot } = action.payload;
      
      // Находим ID предмета, который был экипирован
      const equippedItemId = state.inventory.find(
        item => item.equippedBy === heroId && item.type === slot
      )?.id;

      return {
        ...state,
        inventory: state.inventory.map(item => 
          item.id === equippedItemId
            ? { ...item, equippedBy: null }
            : item
        ),
        equipments: {
          ...state.equipments,
          [heroId]: {
            ...state.equipments[heroId],
            [slot]: null // Очищаем слот
          }
        }
      };
    }

    case 'SET_ERROR':
      return {
        ...state,
        error: action.payload
      };

    case 'SET_LOADING':
      return {
        ...state,
        isLoading: action.payload
      };

    default:
      return state;
  }
};

export const InventoryContext = createContext();

export const InventoryProvider = ({ children }) => {
  const [state, dispatch] = useReducer(inventoryReducer, initialState);

  return (
    <InventoryContext.Provider value={{ state, dispatch }}>
      {children}
    </InventoryContext.Provider>
  );
};