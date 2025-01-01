import { Dimensions, Platform } from 'react-native';

const { width, height } = Dimensions.get('window');

// Определение: телефон или веб
const isMobile = Platform.OS !== 'web' && width < 768;

// Базовые размеры
const guidelineBaseWidth = isMobile ? 350 : 1440;
const guidelineBaseHeight = isMobile ? 680 : 768;

// Функции масштабирования
export const scale = size => (width / guidelineBaseWidth) * size;
export const verticalScale = size => (height / guidelineBaseHeight) * size;
export const moderateScale = (size, factor = 0.5) => size + (scale(size) - size) * factor;

// Размеры экрана
export const METRICS = {
  screenWidth: width,
  screenHeight: height,
  
  // Отступы
  spacing: {
    xs: scale(4),
    sm: scale(8),
    md: scale(16),
    lg: scale(24),
    xl: scale(32),
  },
  
  // Радиусы скругления
  radius: {
    xs: scale(4),
    sm: scale(8),
    md: scale(12),
    lg: scale(16),
    xl: scale(24),
  },
};