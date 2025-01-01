import { scale, verticalScale } from './metrics';

export const LAYOUT = {

  tabBar: {
    height: verticalScale(50),      // было 70-80
    buttonSize: scale(34),          // было 50-60
    iconSize: scale(25),           
    borderRadius: scale(16),
    margin: scale(2),             
  },


  // Размеры иконок
  icons: {
    xs: scale(4),
    sm: scale(8),
    md: scale(12),
    lg: scale(16),
    xl: scale(32),  
  },

  // Размеры кнопок
  buttons: {
    height: verticalScale(50),
    minWidth: scale(60),
    borderRadius: scale(22),
  },

  // Размеры карточек
  cards: {
    borderRadius: scale(2),
    padding: scale(2),
    margin: scale(2),
  },

  // Размеры модальных окон
  modal: {
    width: scale(300),
    padding: scale(20),
    borderRadius: scale(20),
  },
};