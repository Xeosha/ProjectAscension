import { COLORS } from './colors';
import { METRICS, scale, verticalScale, moderateScale } from './metrics';
import { TYPOGRAPHY } from './typography';
import { LAYOUT } from './layout';

export {
  COLORS,
  METRICS,
  TYPOGRAPHY,
  LAYOUT,
  // Вспомогательные функции
  scale,
  verticalScale,
  moderateScale,
};

// Пример использования в компонентах:
/*
import { COLORS, METRICS, TYPOGRAPHY, LAYOUT } from '../constants/theme';

const styles = StyleSheet.create({
  container: {
    padding: METRICS.spacing.md,
    backgroundColor: COLORS.background,
  },
  title: {
    fontSize: TYPOGRAPHY.sizes.xl,
    fontWeight: TYPOGRAPHY.weights.bold,
    color: COLORS.text,
  },
  avatar: {
    width: LAYOUT.avatar.characterWidth,
    height: LAYOUT.avatar.characterHeight,
  },
});
*/