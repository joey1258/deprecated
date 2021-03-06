﻿/**
 * This file is part of SimpleContainer.
 *
 * Licensed under The MIT License
 * For full copyright and license information, please see the MIT-LICENSE.txt
 * Redistributions of files must retain the above copyright notice.
 *
 * @copyright Joey1258
 * @link https://github.com/joey1258
 * @license http://www.opensource.org/licenses/mit-license.php MIT License
 */

using System;
using System.Collections;
using Utils;

namespace SimpleContainer.Container
{
    public class PrefabInfo
    {
        #region property

        /// <summary>
        /// 资源对象
        /// </summary>
        public UnityEngine.Object prefab
        {
            get
            {
                return _prefab ?? ResourcesLoad();
            }
        }
        private UnityEngine.Object _prefab;

        /// <summary>
        /// prefab 上的组件
        /// </summary>
        public Type type { get; set; }

        /// <summary>
        /// 资源路径
        /// </summary>
        public string path { get; set; }

        #endregion

        #region constructor

        public PrefabInfo(UnityEngine.Object prefab, string path, Type type)
        {
            _prefab = prefab;
            this.path = path;
            this.type = type;
        }

        public PrefabInfo(string path, Type type)
        {
            this.path = path;
            this.type = type;
        }

        #endregion

        #region functions

        /// <summary>
        /// 加载资源
        /// </summary>
        private UnityEngine.Object ResourcesLoad()
        {
            _prefab = UnityEngine.Resources.Load(path);
            if (_prefab == null)
            {
                throw new Exceptions(
                    string.Format(Exceptions.RESOURCES_LOAD_FAILURE, path));
            }
            return _prefab;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void UnloadAsset()
        {
            UnityEngine.Resources.UnloadAsset(_prefab);
            _prefab = null;
        }

        #endregion
    }
}